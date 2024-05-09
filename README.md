## La API ProductsManagement esta desarrollada bajo el framework .NET 6, la cual tiene implementados los servicios de autenticación y autorización mediante roles. 

### Se encuentra desplegada en un app service de Azure a la cual se le deja habilitado el swagger para poder testearla desde ahi.

	https://productsmanagementapi20240508184044.azurewebsites.net/swagger/index.html

### La base de datos es una base de datos SQL alojada en Azure, los datos de conexión se encuentran a continuación:

	Server = tcp:testing-harold.database.windows.net,1433;
	Initial Catalog = ProductManagement;	
 	User ID = testingHarold;
 	Password = Hap12345678;

### Para ejecutar la aplicación localmente, solo basta con ejecutar la aplicación para que se ejecuten las migraciones a la base de datos en caso tal esta no exista.

### Al iniciar la API, se crean automáticamente roles y usuarios para tener permisos a los endpoints y son los siguientes:

 	Usuario: AdminUser | Contraseña: Admin*123 | Rol: Admin
	Usuario: UserClient | Contraseña: User*123 | Rol: Client

### Los endpoints que se crearon se describen a continuación:

	api/Authenticate/login - permite hacer la autenticación mediante usuario y contraseña para generar el token que permite acceder a los demas servicios
 	api/Authenticate/register-admin - permite registrar un usuario con rol administrador
	api/Authenticate/register - permite registrar un usuario con rol cliente (requiere token de autenticación, solo tiene permisos el rol Admin)
 
 	api/Products - permite consultar todos los productos creados (requiere token de autenticación) 
	api/Products/Get/{productId} - permite consultar un producto mediante su id (requiere token de autenticación)
 	Post api/Products - permite la creacion de un producto (requiere token de autenticación, solo tiene permisos el rol Admin)
	Put api/Products - permite la actualizacion de un producto (requiere token de autenticación, solo tiene permisos el rol Admin)
 	api/Products/Delete/{productId} - permite la eliminacion de un producto mediante su id (requiere token de autenticación, solo tiene permisos el rol Admin)

### Se comparte colección de postman para ejecutar todos los servicios desplegados en el app service de azure 

	https://github.com/harold-alcazar/ProductsManagement/files/15256923/ProductsManagement.postman_collection.json

 	

