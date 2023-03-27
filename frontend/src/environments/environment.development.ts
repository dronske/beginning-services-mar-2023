import '../mocks/browser';
export const environment = {
  locationsApi: 'http://localhost:1337/',
  auth: {
    authority: 'http://localhost:8090',
    clientId: 'default',
    scope: 'openid profile offline_access',
  },
};
 