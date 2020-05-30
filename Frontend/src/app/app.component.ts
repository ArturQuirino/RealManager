import { Component } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    iconRegistry.addSvgIcon(
      'arrow-back',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/icons/arrow_back-24px.svg')
    );

    iconRegistry.addSvgIcon(
      'account-box',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/icons/account_box-24px.svg')
    );

    iconRegistry.addSvgIcon(
      'assessment',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/icons/assessment-24px.svg')
    );

    iconRegistry.addSvgIcon(
      'calendar-view-day',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/icons/calendar_view_day-24px.svg')
    );

    iconRegistry.addSvgIcon(
      'keyboard-capslock',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/icons/keyboard_capslock-24px.svg')
    );

    iconRegistry.addSvgIcon(
      'monetization-on',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/icons/monetization_on-24px.svg')
    );
  }

  title = 'real-manager';
}
