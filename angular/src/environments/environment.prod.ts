import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'CloverAce',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44352/',
    redirectUri: baseUrl,
    clientId: 'CloverAce_App',
    responseType: 'code',
    scope: 'offline_access CloverAce',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44352',
      rootNamespace: 'CloverAce',
    },
  },
} as Environment;
