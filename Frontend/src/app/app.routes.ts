import { Routes } from '@angular/router';
import { it01Resolver } from './resolvers/it01.resolver';

export const routes: Routes = [
  { path: '', redirectTo: 'users', pathMatch: 'full' },
  {
    path: 'users',
    loadComponent: () => import('./features/it01/it01').then(m => m.It01),
    resolve: { users: it01Resolver }
  }
];