import { useState, useEffect } from "react";

function MedicineForm({ initialData, onSubmit, onCancel }) {
  const [formData, setFormData] = useState({
    id: "",
    name: "",
    supplierCompany: "",
    usageList: "",
    storageLocationId: "",
    requiresPrescription: false,
    isAvailable: true,
    price: 0,
  });

  useEffect(() => {
    if (initialData) setFormData(initialData);
  }, [initialData]);

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData({
      ...formData,
      [name]: type === "checkbox" ? checked : value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit({ ...formData, price: parseFloat(formData.price) });
  };

  return (
    <form onSubmit={handleSubmit} className="mb-4">
      <div className="mb-2">
        <input
          className="form-control"
          name="name"
          placeholder="Nome"
          value={formData.name}
          onChange={handleChange}
          required
        />
      </div>
      <div className="mb-2">
        <input
          className="form-control"
          name="supplierCompany"
          placeholder="Ditta Fornitrice"
          value={formData.supplierCompany}
          onChange={handleChange}
          required
        />
      </div>
      <div className="mb-2">
        <input
          className="form-control"
          name="usageList"
          placeholder="Elenco Usi"
          value={formData.usageList}
          onChange={handleChange}
          required
        />
      </div>
      <div className="mb-2">
        <input
          className="form-control"
          name="storageLocationId"
          placeholder="ID Posizione Magazzino"
          value={formData.storageLocationId}
          onChange={handleChange}
          required
        />
      </div>
      <div className="mb-2">
        <input
          className="form-control"
          name="price"
          placeholder="Prezzo"
          type="number"
          step="0.01"
          value={formData.price}
          onChange={handleChange}
          required
        />
      </div>
      <div className="form-check mb-2">
        <input
          className="form-check-input"
          type="checkbox"
          name="requiresPrescription"
          checked={formData.requiresPrescription}
          onChange={handleChange}
        />
        <label className="form-check-label">Richiede Prescrizione</label>
      </div>
      <div className="form-check mb-2">
        <input
          className="form-check-input"
          type="checkbox"
          name="isAvailable"
          checked={formData.isAvailable}
          onChange={handleChange}
        />
        <label className="form-check-label">Disponibile</label>
      </div>
      <button type="submit" className="btn btn-success me-2">
        Salva
      </button>
      <button type="button" className="btn btn-secondary" onClick={onCancel}>
        Annulla
      </button>
    </form>
  );
}

export default MedicineForm;
