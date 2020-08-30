import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './helpers/auth.guard';

import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { GitRepositoryComponent } from './git-repository/git-repository.component';
import { FavoritesComponent } from './favorites/favorite.component';

const routes: Routes = [
  { path: '', component: GitRepositoryComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'favorites', component: FavoritesComponent },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
