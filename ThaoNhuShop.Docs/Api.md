# ThaoNhuShopAPI

- [ThaoNhuShopAPI](#thaonhushopapi)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "phone": "0961191732",
    "password": "1Leduytuanvu",
    "fullName": "LE DUY TUAN VU"
}
```

#### Register Response

```json
{
    "id": "2e63341a-e627-48ac-bb1a-9d56e2e9cc4f",
    "phone": "0961191732",
    "fullName": "LE DUY TUAN VU"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "phone": "0961191732",
    "password": "1Leduytuanvu"
}
```

#### Login Response

```json
{
    "id": "2e63341a-e627-48ac-bb1a-9d56e2e9cc4f",
    "phone": "0961191732",
    "fullName": "LE DUY TUAN VU"
}
```
