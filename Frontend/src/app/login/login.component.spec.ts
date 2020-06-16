import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginComponent } from './login.component';
import { Router } from '@angular/router';
import { LoginApiService } from '../shared/services/login-api.service';
import { Observable, of } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/modules/material.module';

class RouterMock {
  public navigate() { }
}

class LoginApiServiceMock {}

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [LoginComponent],
      imports: [ReactiveFormsModule, MaterialModule],
      providers: [
        { provide: Router, useValue: RouterMock },
        { provide: LoginApiService, useValue: LoginApiServiceMock }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  fit('should set invalidUser when user/password invalid', () => {
    const loginApiService = jasmine.createSpyObj('LoginApiService', ['login']);
    loginApiService.login.and.returnValue(Observable.throw({status: 401}));
    component.signin({email: 'test', password: 'test'});
    expect(component.usarioSenhaInvalido).toBeTruthy();
  });
});
