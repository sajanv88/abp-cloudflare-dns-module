import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class CloudflareService {
  apiName = 'Cloudflare';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/Cloudflare/sample' },
      { apiName: this.apiName }
    );
  }
}
