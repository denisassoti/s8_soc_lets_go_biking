# Lidaou Denis ASSOTI

## PROCEDURE DE PRISE EN MAIN DES DIFFERENTES PARTIES DU PROJET

Vous pourrai lancer le WebProxyService et le RoutingService dans visual studio en ouvrant la solution LetsGoBiking.sln se trouvant dans le repertoire LetsGoBiking\ ou lancer ces projets individuellement en executant leur fichier .exe.

### WebProxyService

    Lancer le serveur web proxy :
    ```
    Executez ` WebProxyService.exe ` se trouvant dans le dossier WebProxyService\WebProxyService\bin\Debug
    ```

### RoutingService

    Lancer le serveur routing :
    ```
    Executez ` RoutingWithBikesHost.exe ` se trouvant dans le dossier RoutingWithBikesHost\RoutingWithBikesHost\bin\Debug
    ```

NB : Pour lancer le serveur routing, il faut lancer le serveur web proxy avant.

### LightWebClient

    Lancer le client web :
    ```
    Le client web ayant été développé en angular, pour le lancer le projet déjà buildé il est nécéssaire de disposer d'un serveur web d'abord (Wampp ou Xampp ou Nginx ou http-server)
    pour le lancer avec `http-server` :
        ```
        installez http-server en tant que paquet npm avec  `npm install http-server -g`
        puis executez `http-server` dans le repertoire LightWebClient\dist\LightWebClient\ pour lancer le serveur web
        Vous devrez pouvoir accéder au client web à l'adresse http://localhost:8080/
        ```
    ```

### HeavyWinFormsClient

    Lancer le client windows (WinForms) :
    ```
    Executez ` HeavyWinFormsClient.exe ` se trouvant dans le dossier HeavyWinFormsClient\HeavyWinFormsClient\bin\Debug\net6.0-windows\
    ```
    
 ### Some screenshots
 
 ![image1](https://user-images.githubusercontent.com/58354924/179329199-6fb792fc-6b88-43fa-8744-b21700d82bc6.png)
![image2](https://user-images.githubusercontent.com/58354924/179329204-7f408953-d347-4b59-b66f-59daa09c40a1.png)

