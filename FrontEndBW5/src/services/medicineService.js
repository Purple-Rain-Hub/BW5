const BASE_URL = "https://localhost:7030/api/Medicine";

const token =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBjbGluaWNhLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJBZG1pbiBBZG1pbiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzQ5NzU2MTQ4LCJpc3MiOiJodHRwczovL3N0dWRlbnRBcGkuY29tIiwiYXVkIjoiaHR0cHM6Ly9zdHVkZW50QXBpLmNvbSJ9.8lwjMbOuEAb8rsTLCTK65bIde1j0JQemromMXgZP9C0";

const authHeaders = {
  Authorization: `Bearer ${token}`,
};

export async function getAllMedicines() {
  try {
    const response = await fetch(BASE_URL, {
      headers: {
        ...authHeaders,
      },
    });
    if (!response.ok) throw new Error("Errore nel caricamento delle medicine");
    return await response.json();
  } catch (error) {
    console.error("Errore fetch:", error);
    return [];
  }
}

export async function deleteMedicine(id) {
  try {
    const response = await fetch(`${BASE_URL}/${id}`, {
      method: "DELETE",
      headers: {
        ...authHeaders,
      },
    });
    return response.ok;
  } catch (error) {
    console.error("Errore eliminazione:", error);
    return false;
  }
}

export async function updateMedicine(updatedMedicine) {
  try {
    const response = await fetch(BASE_URL, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
        ...authHeaders,
      },
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
    const response = await fetch(BASE_URL, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        ...authHeaders,
      },
      body: JSON.stringify(newMedicine),
    });
    return response.ok;
  } catch (error) {
    console.error("Errore creazione:", error);
    return false;
  }
}

export async function searchMedicines(query, field = "name") {
  const params = new URLSearchParams();
  params.append(field, query);

  const url = `${BASE_URL}/search?${params.toString()}`;

  try {
    const response = await fetch(url, {
      headers: {
        ...authHeaders,
      },
    });

    if (!response.ok) throw new Error("Errore nella ricerca");

    return await response.json();
  } catch (error) {
    console.error("Errore fetch ricerca:", error);
    return [];
  }
}

export async function getMedicineLocation(id) {
  try {
    const response = await fetch(`${BASE_URL}/location/${id}`, {
      headers: {
        ...authHeaders
      }
    });

    const data = await response.json();
    console.log("Risposta backend:", data);

    return {
      name: data.name,
      location: data.storageLocationId
    };
  } catch (error) {
    console.error("Errore fetch posizione:", error);
    return null;
  }
}



