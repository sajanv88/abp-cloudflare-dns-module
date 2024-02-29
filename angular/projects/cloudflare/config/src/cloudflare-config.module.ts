import { ModuleWithProviders, NgModule } from '@angular/core';
import { CLOUDFLARE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CloudflareConfigModule {
  static forRoot(): ModuleWithProviders<CloudflareConfigModule> {
    return {
      ngModule: CloudflareConfigModule,
      providers: [CLOUDFLARE_ROUTE_PROVIDERS],
    };
  }
}
