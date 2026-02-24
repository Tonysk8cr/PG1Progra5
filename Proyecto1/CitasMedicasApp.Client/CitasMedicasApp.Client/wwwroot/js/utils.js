class ComboHelper {

    static async llenarCombo(url, selectId, valueField, textField) {

        try {

            const response = await fetch(url);
            const data = await response.json();

            const select = document.getElementById(selectId);
            if (!select) return;

            select.innerHTML = "<option value=''>Seleccione...</option>";

            data.forEach(item => {
                select.innerHTML += `
                    <option value="${item[valueField]}">
                        ${item[textField]}
                    </option>
                `;
            });

        } catch (error) {
            console.error("Error llenando combo:", error);
        }
    }
}