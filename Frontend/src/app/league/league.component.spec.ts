import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeagueComponent } from './league.component';
import { LeagueApiService, LeagueTeamApi } from '../shared/services/league-api.service';
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

  it('should sort league by points', () => {
    const leagueApiServiceMockTest = fixture.debugElement.injector.get(LeagueApiService);
    spyOn(leagueApiServiceMockTest, 'getLeagueByTeam').and.callFake(() => {
      return of([
        {position: 3} as LeagueTeamApi,
        {position: 2} as LeagueTeamApi,
        {position: 1} as LeagueTeamApi
      ]);
    });

    component.getDivisionInformation();

    expect(component.leagueDataSource[0].position).toBe(1);
    expect(component.leagueDataSource[1].position).toBe(2);
    expect(component.leagueDataSource[2].position).toBe(3);
  });
});
