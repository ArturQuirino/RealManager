import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  signUpForm;

  constructor(private formBuilder: FormBuilder) {
    this.signUpForm = this.formBuilder.group({
      email: '',
      password: '',
      teamName: ''
    });
  }

  ngOnInit() {
  }

  onSubmitSignUpForm(formValues) {
    console.log(formValues);
  }

}
