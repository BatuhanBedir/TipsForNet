```
builder.Services.AddSwaggerGen(setup=>
{
    var jwtSecuritySchema = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Token'� buraya yaz",
        Reference = new OpenApiReference
        {
         Id = JwtBearerDefaults.AuthenticationScheme,
         Type = ReferenceType.SecurityScheme
        }
    };
    setup.AddSecurityDefinition(jwtSecuritySchema.Reference.Id, jwtSecuritySchema);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecuritySchema,Array.Empty<string>() }
    });
});

--builder.Services.AddSwaggerGen() y�ntemi, Swagger servisini projeye eklemek i�in ASP.NET Core DI (Dependency Injection) 
konteynerine bir hizmet kayd� ekler. Bu hizmet, Swagger/OpenAPI belgelerini olu�turmak i�in kullan�l�r.

--jwtSecuritySchema ad�nda bir OpenApiSecurityScheme nesnesi olu�turulur. Bu nesne, JWT tabanl� kimlik do�rulamas�n� 
temsil eder ve Swagger belgelerinde kullan�lacak bir g�venlik �emas� tan�mlar.

BearerFormat �zelli�i, kullan�lacak JWT bi�imini belirtir (JWT olarak ayarland�).

Name �zelli�i, g�venlik �emas�n�n ad�n� belirtir (JWT Authentication olarak ayarland�).

In �zelli�i, g�venlik �emas�n�n JWT'nin hangi b�l�m�nde bulunaca��n� belirtir (header olarak ayarland�).

Type �zelli�i, g�venlik �emas�n�n HTTP tabanl� oldu�unu belirtir (SecuritySchemeType.Http olarak ayarland�).

Scheme �zelli�i, g�venlik �emas�n�n JWT kimlik do�rulama �emas�n� belirtir (JwtBearerDefaults.AuthenticationScheme olarak ayarland�).

Description �zelli�i, Swagger belgelerinde bu g�venlik �emas� i�in a��klama sa�lar (Token'� buraya yaz olarak ayarland�).

--jwtSecuritySchema'n�n bir referans�n� i�eren bir OpenApiReference nesnesi olu�turulur. Bu, JWT g�venlik �emas�n�n Swagger 
belgelerinde referans olarak kullan�lmas�n� sa�lar.

Id �zelli�i, g�venlik �emas�n�n benzersiz bir kimlik belirleyicisini belirtir (JwtBearerDefaults.AuthenticationScheme ile ayn� 
de�ere ayarland�).
Type �zelli�i, referans�n bir g�venlik �emas� referans� oldu�unu belirtir.

--setup.AddSecurityDefinition() y�ntemiyle, olu�turulan JWT g�venlik �emas� tan�m� Swagger/OpenAPI belgelerine eklenir. 
Bu, Swagger UI'da g�venlik �emas�n� g�stermek i�in kullan�l�r. jwtSecuritySchema.Reference.Id de�eri ile tan�mlanan referans 
kimli�i, g�venlik �emas�n� tan�mlayan nesnenin kimlik bilgisini temsil eder.

-setup.AddSecurityRequirement() y�ntemiyle, g�venlik gereksinimlerini tan�mlayan bir OpenApiSecurityRequirement nesnesi olu�turulur. Bu, Swagger belgelerindeki g�venlik gereksinimlerini belirtir.

{jwtSecuritySchema, Array.Empty<string>()} ifadesiyle, JWT g�venlik �emas�n�n kullan�lmas�n�n zorunlu oldu�u belirtilir. Bu ifade, JWT i�in herhangi bir yetki kural� gerektirmedi�ini belirtir (bo� bir dizi ile temsil edilir).

***Swagger belgelerinde JWT tabanl� kimlik do�rulama �emas�n�n tan�mlanmas�n� ve Swagger UI'da bu g�venlik �emas�n� kullan�c�ya 
g�stermeyi sa�lar. Bu sayede API'nin kimlik do�rulama gereksinimleri ve kullan�m� belgelerde a��k bir �ekilde g�r�nt�lenebilir.

```
