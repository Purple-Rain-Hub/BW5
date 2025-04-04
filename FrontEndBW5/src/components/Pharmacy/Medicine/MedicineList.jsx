import {
  getAllMedicines,
  deleteMedicine,
  updateMedicine,
  addMedicine,
  searchMedicines,
  getMedicineLocation,
} from "../../../services/medicineService";
import MedicineItem from "./MedicineItem";
import MedicineForm from "./MedicineForm";
import { useEffect, useState } from "react";

function MedicineList() {
  const [medicines, setMedicines] = useState([]);
  const [loading, setLoading] = useState(true);
  const [editingMedicine, setEditingMedicine] = useState(null);
  const [creating, setCreating] = useState(false);
  const [search, setSearch] = useState("");
  const [filterField, setFilterField] = useState("name");

  const fetchData = async () => {
    const data = await getAllMedicines();
    setMedicines(data);
    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, []);

  const handleDelete = async (id) => {
    if (!window.confirm("Confermi eliminazione?")) return;
    const success = await deleteMedicine(id);
    if (success) setMedicines((prev) => prev.filter((m) => m.id !== id));
    else alert("Errore eliminazione");
  };

  const handleEdit = (medicine) => {
    setEditingMedicine(medicine);
    setCreating(false);
  };

  const handleUpdate = async (updatedData) => {
    const success = await updateMedicine(updatedData);
    if (success) {
      setMedicines((prev) =>
        prev.map((m) => (m.id === updatedData.id ? updatedData : m))
      );
      setEditingMedicine(null);
    } else {
      alert("Errore aggiornamento");
    }
  };

  const handleCreate = async (newData) => {
    const success = await addMedicine(newData);
    if (success) {
      fetchData();
      setCreating(false);
    } else {
      alert("Errore durante l'inserimento");
    }
  };

  const handleSearch = async () => {
    if (search.trim() === "") {
      fetchData();
      return;
    }

    const results = await searchMedicines(search, filterField);
    setMedicines(results);
  };

  const handleShowLocation = async (id) => {
    const result = await getMedicineLocation(id);
  
    if (!result || !result.location || result.location.length < 3) {
      alert("Posizione non valida o non trovata.");
      return;
    }
  
    const { name, location } = result;
  
    const armadio = location[0];
    const cassetto = location[1];
    const riga = location[2];
  
    alert(`Posizione del medicinale "${name}":
  - Armadio: ${armadio}
  - Cassetto: ${cassetto}
  - Riga: ${riga}`);
  };
  

  return (
    <>
      <div className="input-group mb-3">
        <select
          className="form-select"
          value={filterField}
          onChange={(e) => setFilterField(e.target.value)}
          style={{ maxWidth: "200px" }}
        >
          <option value="name">Nome</option>
          <option value="supplierCompany">Ditta</option>
          <option value="usageList">Uso</option>
        </select>
        <input
          type="text"
          className="form-control"
          placeholder="Cerca..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />
        <button className="btn btn-outline-primary" onClick={handleSearch}>
          Cerca
        </button>
      </div>

      <div className="mb-3">
        {!creating && !editingMedicine && (
          <button className="btn btn-success" onClick={() => setCreating(true)}>
            Aggiungi nuovo medicinale
          </button>
        )}
      </div>

      {(creating || editingMedicine) && (
        <MedicineForm
          initialData={editingMedicine || null}
          onSubmit={creating ? handleCreate : handleUpdate}
          onCancel={() => {
            setCreating(false);
            setEditingMedicine(null);
          }}
        />
      )}

      {loading && <p>Caricamento in corso...</p>}
      {!loading && medicines.length === 0 && <p>Nessun medicinale trovato.</p>}

      <div className="row">
        {medicines.map((medicine) => (
          <div key={medicine.id} className="col-md-4 mb-3">
            <MedicineItem
              medicine={medicine}
              onDelete={handleDelete}
              onEdit={handleEdit}
              onShowLocation={handleShowLocation}
            />
          </div>
        ))}
      </div>
    </>
  );
}

export default MedicineList;
