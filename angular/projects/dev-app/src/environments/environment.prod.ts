import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Cloudflare',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44359/',
    redirectUri: baseUrl,
    clientId: 'Cloudflare_App',
    responseType: 'code',
    scope: 'offline_access Cloudflare',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44359',
      rootNamespace: 'Abp.Dns.Cloudflare',
    },
    Cloudflare: {
      url: 'https://localhost:44316',
      rootNamespace: 'Abp.Dns.Cloudflare',
    },
  },
} as Environment;
