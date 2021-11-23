var config = {

    // Our Node API is being served from localhost:3001
    baseUrl: 'https://localhost:7098/api/',
    // The API specifies that new users register at the POST /users enpoint.
    signupUrl: 'users',
    // Logins happen at the POST /sessions/create endpoint.
    loginUrl: 'Authenticate/login',
    // The API serves its tokens with a key of id_token which differs from
    // aureliauth's standard.
    tokenName: 'id_token',
    // Once logged in, we want to redirect the user to the welcome view.
    loginRedirect: '#/profile',
  
  }
  
  export default config;
