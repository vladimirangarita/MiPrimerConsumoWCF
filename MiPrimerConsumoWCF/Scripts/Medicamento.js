
window.onload = function () {
    ListarMedicamentos();
    ListarFormaFarmaceutica();
}

function ListarFormaFarmaceutica() {
    fetch("Medicamento/ListarFormaFarmaceutica")
        .then(res => res.json())
        .then(res => {
            //
            //
            LlenarCombo(res);
        })
}
function FiltrarDatos() {
    var NombreMedicamento = document.getElementById("txtBuscarNombreMedicamento").value;
    if (NombreMedicamento!="") {
        fetch("Medicamento/BuscarMedicamentosPorNombre/?NombreMedicamento=" + NombreMedicamento)
            .then(res => res.json())
            .then(res => {
                Listar(res);
            })
    } else {
        ListarMedicamentos();
    }
   
}
function LlenarCombo(res) {
    var contenido = "";
    contenido += "<option value=''>--Seleccione--</option>";
    for (var i = 0; i < res.length; i++) {
        contenido += "<option value='" + res[i].IidFormaFarmaceutica + "'>" + res[i].NombreFormaFarmaceutica +"</option>";
    }
    document.getElementById("cboFormaFarmaceutica").innerHTML = contenido;


}
function ListarMedicamentos() {
    fetch("Medicamento/ListarMedicamentos")
        .then(res => res.json())
        .then(res => {

            Listar(res);
        })
}

function Limpiar() {
    var limpiar = document.getElementsByClassName("Limpiar");
    var nlimpiar = limpiar.length;

    for (var i = 0; i < nlimpiar; i++) {
        limpiar[i].value = "";
    }

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
    Limpiar();
    if (iidMedicamento == 0) {
        document.getElementById("lblTitulo").innerHTML = "Agregar Medicamento";
    } else {
        document.getElementById("lblTitulo").innerHTML = "Editar Medicamento";

        fetch("Medicamento/RecuperarMedicamento/?iidMedicamento=" + iidMedicamento)
            .then(res => res.json())
            .then(res => {
                document.getElementById("txtIdMedicamento").value = res.IidMedicamento;
                document.getElementById("txtNombre").value = res.Nombre;
                document.getElementById("txtConcentracion").value = res.Concentracion;
                document.getElementById("cboFormaFarmaceutica").value = res.IidFormaFarmaceutica;
                document.getElementById("txtPrecio").value = res.Precio;
                document.getElementById("txtStock").value = res.Stock;
                document.getElementById("txtPresentacion").value = res.Presentacion;
            })
    }

}

function DatosObligatorios() {
    var exito = true;
    var contenido = "<ol style='color:red'>";
    var controlesObligatorios = document.getElementsByClassName("Obligatorio");
    var ncontroles = controlesObligatorios.length;
    for (var i = 0; i < ncontroles; i++) {
        if (controlesObligatorios[i].value == "") {

            exito = false;
            contenido +="<li>" + controlesObligatorios[i].name + "Es obligatorio</li>"

        }
        
    }
    contenido += "</ol>";
    return { exito, contenido };
}

function Guardar() {
    if (confirm("Deseas guardr los cambios?")==1) {
        var objeto = DatosObligatorios();
        if (objeto.exito==false) {
            document.getElementById("divError").innerHTML = objeto.contenido;

        } else {

        }
    }
}