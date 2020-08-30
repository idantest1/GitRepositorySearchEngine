import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { AuthService } from '../services//auth.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.css'],
})
export class FavoritesComponent implements OnInit {
  constructor(
    private userService: UserService,
    private authService: AuthService
  ) {}
  favorites: any;
  loading: boolean;
  error: string;
  ngOnInit(): void {
    this.getFavorites();
  }

  getFavorites() {
    this.loading = true;
    this.userService
      .getFavorites()
      .pipe(first())
      .subscribe(
        (data) => {
          this.favorites = data;
          this.loading = false;
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
