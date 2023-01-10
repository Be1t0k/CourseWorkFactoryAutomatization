
document.addEventListener('DOMContentLoaded', () => {

    const getSort = ({ target }) => {
        const order = (target.dataset.order = -(target.dataset.order || -1));
        const index = [...target.parentNode.cells].indexOf(target);
        const collator = new Intl.Collator(['en', 'ru'], { numeric: true });
        const comparator = (index, order) => (a, b) => order * collator.compare(
            a.children[index].innerHTML,
            b.children[index].innerHTML
        );

        for (const tBody of target.closest('table').tBodies)
            tBody.append(...[...tBody.rows].sort(comparator(index, order)));

        for (const cell of target.parentNode.cells)
            cell.classList.toggle('sorted', cell === target);
    };

    document.querySelectorAll('.table thead').forEach(tableTH => tableTH.addEventListener('click', () => getSort(event)));

});

document.getElementById("showpasswords").addEventListener("click", function () {
    [...document.querySelectorAll(".password")].forEach(p =>
        p.type = p.type === "password" ? "text" : "password"
    )
})
document.getElementById("registerdetails").addEventListener("submit", function (e) {
    const errSpan = document.getElementById("passwordmatcherror");
    let firstPassword = this.password.value;
    let retypedPassword = this.retypedpassword.value;
    errSpan.classList.toggle("error", firstPassword !== retypedPassword);

    if (firstPassword !== retypedPassword) {
        errSpan.innerHTML = ("Passwords do not match. Please retype");
        e.preventDefault();
    }
});