import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeagueComponent } from './league.component';
import { LeagueApiService } from '../shared/services/league-api.service';
import { of } from 'rxjs';

let leagueApiServiceMock: Partial<LeagueApiService>;

describe('LeagueComponent', () => {
  let component: LeagueComponent;
  let fixture: ComponentFixture<LeagueComponent>;

  beforeEach(async(() => {

    leagueApiServiceMock = {
        getLeagueByTeam: () => of([]),
    };

    TestBed.configureTestingModule({
      declarations: [ LeagueComponent ],
      providers: [
          {provide: LeagueApiService, useValue: leagueApiServiceMock}
        ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeagueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
