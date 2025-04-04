import { useState, useEffect } from "react";
import { addSale, updateSale } from "../../../services/saleService";

function SaleForm({ initialData = null, onSave, onCancel }) {
  const [fiscalCode, setFiscalCode] = useState("");
  const [prescription, setPrescription] = useState("");

  useEffect(() => {
    if (initialData) {
      setFiscalCode(initialData.customerFiscalCode || "");
      setPrescription(initialData.prescriptionNumber || "");
    }
  }, [initialData]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const saleData = {
      id: initialData?.id,
      customerFiscalCode: fiscalCode,
      prescriptionNumber: prescription || null,
    };

    const success = initialData
      ? await updateSale(saleData)
      : await addSale(saleData);

    if (success) {
      alert(initialData ? "Vendita aggiornata con successo!" : "Vendita creata con successo!");
      onSave();
    } else {
      alert("Errore durante il salvataggio.");
    }
  };

  return (
    <form onSubmit={handleSubmit} className="mb-4">
      <h4>{initialData ? "Modifica Vendita" : "Nuova Vendita"}</h4>

      <div className="mb-3">
        <label className="form-label">Codice Fiscale Cliente</label>
        <input
          type="text"
          className="form-control"
          value={fiscalCode}
          onChange={(e) => setFiscalCode(e.target.value)}
          required
        />
      </div>

      <div className="mb-3">
        <label className="form-label">Numero Ricetta (opzionale)</label>
        <input
          type="text"
          className="form-control"
          value={prescription}
          onChange={(e) => setPrescription(e.target.value)}
        />
      </div>

      <button type="submit" className="btn btn-success me-2">
        {initialData ? "Aggiorna" : "Salva"}
      </button>
      <button type="button" className="btn btn-secondary" onClick={onCancel}>
        Annulla
      </button>
    </form>
  );
}

export default SaleForm;
