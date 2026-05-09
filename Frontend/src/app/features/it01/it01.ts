import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DialogService, DynamicDialogModule, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TableModule, TableLazyLoadEvent } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { PaginatedResult } from '@core/models/pagination.model';
import { UserListItem } from '@models/it01.model';
import { UserService } from '@services/it01.service';
import { It01Modal } from './it01-modal/it01-modal';

@Component({
  selector: 'app-it01',
  imports: [TableModule, ButtonModule, DynamicDialogModule, ToastModule],
  templateUrl: './it01.html',
  providers: [DialogService, MessageService],
})
export class It01 {
  private readonly route = inject(ActivatedRoute);
  private readonly userService = inject(UserService);
  private readonly dialogService = inject(DialogService);
  private readonly messageService = inject(MessageService);

  readonly size = 10;
  page = signal(1);
  data = signal<PaginatedResult<UserListItem>>(this.route.snapshot.data['users']);

  onPageChange(event: TableLazyLoadEvent) {
    const first = event.first ?? 0;
    const rows = event.rows ?? this.size;
    const page = Math.floor(first / rows) + 1;
    this.page.set(page);
    this.userService.getUserAll(page, this.size).subscribe((result) => this.data.set(result));
  }

  private openModal(id?: number): DynamicDialogRef<It01Modal> {
    return this.dialogService.open(It01Modal, {
      header: id ? 'ข้อมูลผู้ใช้' : 'เพิ่มผู้ใช้',
      width: '80vw',
      height: '80vh',
      data: { id },
    })!;
  }

  showDetail(id: number) {
    this.openModal(id);
  }

  addUser() {
    this.openModal().onClose.subscribe((result) => {
      if (result) {
        this.onPageChange({ first: 0, rows: this.size });
        this.messageService.add({ severity: 'success', summary: 'สำเร็จ', detail: 'เพิ่มผู้ใช้เรียบร้อยแล้ว' });
      }
    });
  }
}