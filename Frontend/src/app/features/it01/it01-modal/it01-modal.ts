import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ConfirmationService } from 'primeng/api';
import { InputTextModule } from 'primeng/inputtext';
import { DatePickerModule } from 'primeng/datepicker';
import { InputNumberModule } from 'primeng/inputnumber';
import { TextareaModule } from 'primeng/textarea';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { UserService } from '@services/it01.service';

export interface It01ModalData {
  id?: number;
}

@Component({
  selector: 'app-it01-modal',
  imports: [ReactiveFormsModule, InputTextModule, DatePickerModule, InputNumberModule, TextareaModule, ButtonModule, ConfirmDialogModule],
  templateUrl: './it01-modal.html',
  providers: [ConfirmationService],
})
export class It01Modal implements OnInit {
  readonly dialogRef = inject(DynamicDialogRef);
  readonly config = inject(DynamicDialogConfig);
  private readonly fb = inject(FormBuilder);
  private readonly userService = inject(UserService);
  private readonly confirmationService = inject(ConfirmationService);

  data: It01ModalData = this.config.data;
  isCreateMode = !this.data.id;
  today = new Date();

  form = this.fb.group({
    name: ['', Validators.required],
    lastname: ['', Validators.required],
    dob: [null as Date | null, Validators.required],
    age: [{ value: 0, disabled: true }],
    address: [''],
  });

  constructor() {
    this.form
      .get('dob')!
      .valueChanges.pipe(takeUntilDestroyed())
      .subscribe((dob) => {
        if (!dob) return;
        const today = new Date();
        let age = today.getFullYear() - dob.getFullYear();
        const notYet =
          today.getMonth() < dob.getMonth() ||
          (today.getMonth() === dob.getMonth() && today.getDate() < dob.getDate());
        if (notYet) age--;
        this.form.get('age')!.setValue(age, { emitEvent: false });
      });
  }

  ngOnInit() {
    if (!this.isCreateMode) {
      this.userService.getUserById(this.data.id!).subscribe((user) => {
        this.form.patchValue({
          name: user.name,
          lastname: user.lastname,
          dob: user.dob ? new Date(user.dob + 'T00:00:00') : null,
          age: user.age,
          address: user.address,
        });
        this.form.disable();
      });
    }
  }

  save() {
    if (this.form.invalid) return;
    this.confirmationService.confirm({
      message: 'ยืนยันการบันทึกข้อมูล?',
      header: 'ยืนยัน',
      icon: 'pi pi-question-circle',
      accept: () => {
        const { name, lastname, dob, address } = this.form.value;
        const dobStr = dob
          ? `${dob.getFullYear()}-${String(dob.getMonth() + 1).padStart(2, '0')}-${String(dob.getDate()).padStart(2, '0')}`
          : '';
        this.userService
          .createUser({ name: name!, lastname: lastname!, dob: dobStr, address: address! })
          .subscribe(() => this.dialogRef.close(true));
      },
    });
  }

  close() {
    this.dialogRef.close();
  }
}