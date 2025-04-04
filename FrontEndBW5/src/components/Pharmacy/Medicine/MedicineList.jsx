import { getAllMedicines, deleteMedicine, updateMedicine, addMedicine } from '../../../services/medicineService'
import MedicineItem from './MedicineItem'
import MedicineForm from './MedicineForm'
import { useEffect, useState } from 'react'

function MedicineList() {
  const [medicines, setMedicines] = useState([])
  const [loading, setLoading] = useState(true)
  const [editingMedicine, setEditingMedicine] = useState(null)
  const [creating, setCreating] = useState(false)

  const fetchData = async () => {
    const data = await getAllMedicines()
    setMedicines(data)
    setLoading(false)
  }

  useEffect(() => {
    fetchData()
  }, [])

  const handleDelete = async (id) => {
    if (!window.confirm('Confermi eliminazione?')) return
    const success = await deleteMedicine(id)
    if (success) setMedicines(prev => prev.filter(m => m.id !== id))
    else alert('Errore eliminazione')
  }

  const handleEdit = (medicine) => {
    setEditingMedicine(medicine)
    setCreating(false)
  }

  const handleUpdate = async (updatedData) => {
    const success = await updateMedicine(updatedData)
    if (success) {
      setMedicines(prev =>
        prev.map(m => m.id === updatedData.id ? updatedData : m)
      )
      setEditingMedicine(null)
    } else {
      alert('Errore aggiornamento')
    }
  }

  const handleCreate = async (newData) => {
    const success = await addMedicine(newData)
    if (success) {
      fetchData()
      setCreating(false)
    } else {
      alert('Errore durante l\'inserimento')
    }
  }

  return (
    <>
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
            setCreating(false)
            setEditingMedicine(null)
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
            />
          </div>
        ))}
      </div>
    </>
  )
}

export default MedicineList
