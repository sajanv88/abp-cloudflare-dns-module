import { TestBed } from '@angular/core/testing';
import { CloudflareService } from './services/cloudflare.service';
import { RestService } from '@abp/ng.core';

describe('CloudflareService', () => {
  let service: CloudflareService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(CloudflareService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
