import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CloudflareComponent } from './components/cloudflare.component';
import { CloudflareRoutingModule } from './cloudflare-routing.module';

@NgModule({
  declarations: [CloudflareComponent],
  imports: [CoreModule, ThemeSharedModule, CloudflareRoutingModule],
  exports: [CloudflareComponent],
})
export class CloudflareModule {
  static forChild(): ModuleWithProviders<CloudflareModule> {
    return {
      ngModule: CloudflareModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CloudflareModule> {
    return new LazyModuleFactory(CloudflareModule.forChild());
  }
}
