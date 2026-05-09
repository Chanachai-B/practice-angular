import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { PaginatedResult } from '@core/models/pagination.model';
import { UserListItem } from '@models/it01.model';
import { UserService } from '@services/it01.service';

export const it01Resolver: ResolveFn<PaginatedResult<UserListItem>> = () => inject(UserService).getUserAll();