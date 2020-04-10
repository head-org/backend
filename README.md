Miso .NET Core server
===============

To run the app execute the following command:

```sh
docker-compose -f docker-compose.yml.local up -d
```

It will be served by default on http://localhost:5000

In order to generate a Bearer token to authenticate the API requests a JWT Bearer token must be generated. You can use an online generator like http://jwtbuilder.jamiekurtz.com/

Only the following fields should be specified:

- Issuer
- Issued At
- Expiration
- Audience
- Key