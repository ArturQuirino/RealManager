import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchesComponent } from './matches.component';
import { MatchApiService } from '../shared/services/match-api.service';
import { of } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/modules/material.module';
import { MatchComponent } from './match/match.component';

let matchApiServiceMock: Partial<MatchApiService>;

describe('MatchesComponent', () => {
  let component: MatchesComponent;
  let fixture: ComponentFixture<MatchesComponent>;

  beforeEach(async(() => {

    matchApiServiceMock = {
        getMatchesByTeamId: () => of([])
    };

    TestBed.configureTestingModule({
      declarations: [ MatchesComponent ],
      imports: [ReactiveFormsModule, MaterialModule],
      providers: [
          { provide: MatchApiService, useValue: matchApiServiceMock }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatchesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
