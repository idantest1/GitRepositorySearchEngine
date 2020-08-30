import { Component } from '@angular/core';

import { User } from '../models/user';
import { first } from 'rxjs/operators';
import { GitRepositoriesService } from '../services/git-repositories.service';
import { UserService } from '../services/user.service';
import { AuthService } from '../services//auth.service';

@Component({ templateUrl: 'git-repository.component.html' })
export class GitRepositoryComponent {
  user: User;
  loading: boolean = false;
  addingToFavorite: boolean = false;
  error: string;
  selectionModel: string;
  serachTerm: string;

  constructor(
    private gitRepositoriesService: GitRepositoriesService,
    private userService: UserService,
    private authService: AuthService
  ) {}

  repositoryResults: any;
  getRepositories(searchTerm) {
    this.loading = true;
    this.gitRepositoriesService
      .search(searchTerm)
      .pipe(first())
      .subscribe(
        (data) => {
          this.repositoryResults = data;
          this.loading = false;
        },
        (error) => {
          this.error = error;
        }
      );
  }

  searchRepositories(searchTerm) {
    this.getRepositories(searchTerm);
  }

  addToFavorites(favorite) {
    this.addingToFavorite = true;
    this.userService
      .addFavorites({ Favorites: [favorite] })
      .pipe(first())
      .subscribe(
        (data) => {
          this.addingToFavorite = false;
        },
        (error) => {
          this.error = error;
        }
      );
  }

  logout() {
    this.authService.logout();
  }
}

//GitRepositoryComponent
