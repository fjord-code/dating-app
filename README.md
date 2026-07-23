# DatingAPP
Dating app from a .NET/Angular course.

## Running the client
In order to run the client over https you need to add sertificates to the /client/ssl folder. I've used the mkcert tool for that purpose.
```bash
mkcert -install
cd client
cd ssl
mkcert localhost
```
