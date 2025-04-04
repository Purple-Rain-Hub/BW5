const BASE_URL = "https://localhost:7030/api/Medicine";

export async function getAllMedicines() {
  try {
    const response = await fetch(BASE_URL);
    if (!response.ok) throw new Error("Errore nel caricamento delle medicine");
    return await response.json();
  } catch (error) {
    console.error("Errore fetch:", error);
    return [];
  }
}

export async function deleteMedicine(id) {
  try {
    const response = await fetch(`https://localhost:7030/api/Medicine/${id}`, {
      method: "DELETE",
    });
    return response.ok;
  } catch (error) {
    console.error("Errore eliminazione:", error);
    return false;
  }
}

export async function updateMedicine(updatedMedicine) {
  try {
    const response = await fetch("https://localhost:7030/api/Medicine", {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(updatedMedicine),
    });
    return response.ok;
  } catch (error) {
    console.error("Errore aggiornamento:", error);
    return false;
  }
}

export async function addMedicine(newMedicine) {
    try {
      const response = await fetch('https://localhost:7030/api/Medicine', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newMedicine)
      })
      return response.ok
    } catch (error) {
      console.error('Errore creazione:', error)
      return false
    }
  }
  