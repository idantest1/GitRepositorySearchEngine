import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GitRepositoriesService {
  constructor(private router: Router, private http: HttpClient) {
    // this.userSubject = new BehaviorSubject<string>(
    //   JSON.parse(localStorage.getItem('user'))
    // );
    // this.user = this.userSubject.asObservable();
  }

  search(searchTerm) {
    return this.http
      .get(`${environment.apiUrl}/GitRepositories/Search/${searchTerm}`)
      .pipe(
        map((user) => {
          return user;
        })
      );
  }
}
