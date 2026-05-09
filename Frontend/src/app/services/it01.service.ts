import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { PaginatedResult } from '@core/models/pagination.model';
import { CreateUserRequest, User, UserListItem } from '@models/it01.model';

@Injectable({ providedIn: 'root' })
export class UserService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.apiUrl}/api/it01`;

  getUserAll(page = 1, size = 10): Observable<PaginatedResult<UserListItem>> {
    const params = new HttpParams().set('page', page).set('size', size);
    return this.http.get<PaginatedResult<UserListItem>>(this.baseUrl, { params });
  }

  getUserById(id: number): Observable<User> {
    const params = new HttpParams().set('id', id);
    return this.http.get<User>(`${this.baseUrl}/user`, { params });
  }

  createUser(data: CreateUserRequest): Observable<void> {
    return this.http.post<void>(this.baseUrl, data);
  }
}