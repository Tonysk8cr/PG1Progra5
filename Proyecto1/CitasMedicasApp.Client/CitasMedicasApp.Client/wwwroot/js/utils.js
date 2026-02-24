class ComboHelper {

    static async llenarCombo(url, selectId, valueField, textBuilder) {

        try {

            const response = await fetch(url);
            const data = await response.json();

            const select = document.getElementById(selectId);
            if (!select) return;

            select.innerHTML = "<option value=''>Seleccione...</option>";

            data.forEach(item => {

                // Si es función → usar función
                const texto = typeof textBuilder === "function"
                    ? textBuilder(item)
                    : item[textBuilder];

                select.innerHTML += `
                    <option value="${item[valueField]}">
                        ${texto}
                    </option>
                `;
            });

        } catch (error) {
            console.error("Error llenando combo:", error);
        }
    }
}