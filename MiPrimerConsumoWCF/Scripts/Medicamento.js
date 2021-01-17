
window.onload = function () {
    ListarMedicamentos()
}



function ListarMedicamentos() {
    fetch("Medicamento/ListarMedicamentos")
        .then(res => res.json())
        .then(res => {

            Listar(res);
        })
}

function Listar(res) {
    var contenido = "";

    contenido += "<table class='table'>";
    contenido += "<thead class='table-dark'>";
    //Definimos las filas(definimos la primera fila)
    contenido += "<tr>";
    contenido += "<th>Id Medicamento</th>"
    contenido += "<th>Nombre</th>"
    contenido += "<th>Concentracion</th>"
    contenido += "<th>Forma</th>"
    contenido += "<th>Stock</th>"
    contenido += "<th>Precio</th>"
    contenido += "<th>Presentacion</th>"
    contenido += "<th>Operaciones</th>"
    contenido += "</tr>";

    contenido += "</thead>";

    contenido += "<tbody>";

    for (var i = 0; i < res.length; i++) {
        var item = res[i];

        contenido += "<tr>";

        contenido += "<td>" + item.IidMedicamento + "</td>";
        contenido += "<td>" + item.Nombre + "</td>";
        contenido += "<td>" + item.Concentracion + "</td>";
        contenido += "<td>" + item.NombreFormaFarmaceutica + "</td>";
        contenido += "<td>" + item.Stock + "</td>";
        contenido += "<td>" + item.Precio + "</td>";
        contenido += "<td>" + item.Presentacion + "</td>";
        contenido += "<td><input type='button' class='btn btn-primary' onclick='AbrirModal("+item.IidMedicamento+")' value='Editar' data-toggle='modal' data-target='#exampleModal'/>";
        contenido += "<input type='button' class='btn btn-danger' value='Eliminar'/></td>";
        contenido += "</tr>";

    }
    contenido += "</tbody>";

    contenido += "</table>";

    document.getElementById("divTabla").innerHTML = contenido;

}

function AbrirModal(iidMedicamento) {

    if (iidMedicamento==0) {
        document.getElementById("lblTitulo").innerHTML = "Agregar Medicamento";
    } else {
        document.getElementById("lblTitulo").innerHTML = "Editar Medicamento";
    }

}