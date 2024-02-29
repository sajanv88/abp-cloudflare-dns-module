import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { CloudflareComponent } from './components/cloudflare.component';
import { CloudflareService } from '@abp.Dns/cloudflare';
import { of } from 'rxjs';

describe('CloudflareComponent', () => {
  let component: CloudflareComponent;
  let fixture: ComponentFixture<CloudflareComponent>;
  const mockCloudflareService = jasmine.createSpyObj('CloudflareService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [CloudflareComponent],
      providers: [
        {
          provide: CloudflareService,
          useValue: mockCloudflareService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CloudflareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
