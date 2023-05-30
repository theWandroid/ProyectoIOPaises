Es un programa que almacena información básica sobre países. 
Hay un menu con 7 opciones:
1 - Añadir pais
2 - Buscar país
3 - Listar paises
4 - Ordenar por población
5 - Añadir ciudades
6 - Borrar país
7 - Cerrar programa

Al inicializar el programa lee un archivo que se llama "Countries.txt" que contiene información guardada sobre los países y la añade a un vector de paises.

"país/capital/población/superficie/ciudades"

Se muestra el menu, hasta que no se introduzca una de las 7 opciones el menu seguirá apareciendo.

=> La opción 1 hace referecia a la función AddCountry. Esta función pedira un nombre de pais, solo añadira el país si no se encuentra dentro del vector, que pedira entonces la capital, población y la superficie, entonces ara referencia a la función InsertCountry.

=> La opción 2 hace referencia a la función SearchCountry. Esta función pedira un nombre de país y lo buscara en el vector de paises. Si esta lo mostrara por pantalla.

=> La opción 3 hace referencia a la función ListCountries, que lista los paises que se encuentran dentro del vector de paises.

=> La opción 4 lista los paises que esta dentro del vector de paises ordenados por población.

=> La opción 5 hace referencia a la función AddCities que añade ciudades a un país dentro del vector de países.

=> La opción 6 hace referencia a la función EraseCountry, que borra un país que esta dentro del vector de paises.