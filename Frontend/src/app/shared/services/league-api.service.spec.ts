import { TestBed } from '@angular/core/testing';

import { LeagueApiService } from './league-api.service';

describe('LeagueApiService', () => {
  let service: LeagueApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LeagueApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
