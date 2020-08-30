import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AuthService } from '../services/auth.service';

@Component({ templateUrl: 'register.component.html' })
export class RegisterComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;
  error: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService // private accountService: AccountService, // private alertService: AlertService
  ) {}

  ngOnInit() {
    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.form.controls;
  }

  onSubmit() {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    this.authService
      .register(this.form.value)
      .pipe(first())
      .subscribe(
        (data) => {
          this.router.navigate(['../login'], { relativeTo: this.route });
        },
        (error) => {
          this.loading = false;
          this.error = error;
        }
      );
  }
}
