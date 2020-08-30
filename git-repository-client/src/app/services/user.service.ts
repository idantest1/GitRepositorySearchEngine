import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private router: Router, private http: HttpClient) {}

  getFavorites() {
    return this.http.get(`${environment.apiUrl}/User/Favorites`).pipe(
      map((favorite) => {
        return favorite;
      })
    );
  }

  addFavorites(Favorites) {
    return this.http
      .post(`${environment.apiUrl}/User/Favorites`, Favorites)
      .pipe(
        map((user) => {
          return user;
        })
      );
  }
}
