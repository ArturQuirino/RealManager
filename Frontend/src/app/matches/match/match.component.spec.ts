import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MatchComponent } from './match.component';
import { MatchApiService } from 'src/app/shared/services/match-api.service';
import { of } from 'rxjs';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';

let matchApiServiceMock: Partial<MatchApiService>;
let activedRouteMock: Partial<ActivatedRoute>;

describe('MatchComponent', () => {
  let component: MatchComponent;
  let fixture: ComponentFixture<MatchComponent>;

  beforeEach(async(() => {
    matchApiServiceMock = {
        getMatchById: () => of()
    };

    activedRouteMock = new ActivatedRoute();
    activedRouteMock.snapshot = new ActivatedRouteSnapshot();
    activedRouteMock.snapshot.paramMap.get = () => '123';

    TestBed.configureTestingModule({
      declarations: [ MatchComponent ],
      providers: [
          { provide: MatchApiService, useValue: matchApiServiceMock },
          { provide: ActivatedRoute, useValue: activedRouteMock }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
