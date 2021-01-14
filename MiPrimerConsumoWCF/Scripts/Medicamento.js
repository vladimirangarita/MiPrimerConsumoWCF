
ListarMedicamentos();

function ListarMedicamentos() {
    fetch("Medicamento/ListarMedicamentos")
        .then(res => res.json())
        .then(res => {

            alert(res);
        })
}