window.showToast = function showToast(message, type) {
    const toastContainer = document.createElement("div");
    toastContainer.textContent = message;
    toastContainer.style.position = "fixed";
    toastContainer.style.bottom = "20px";
    toastContainer.style.right = "20px";
    toastContainer.style.padding = "10px 20px";
    toastContainer.style.borderRadius = "5px";
    toastContainer.style.color = "#fff";
    toastContainer.style.zIndex = "1000";
    toastContainer.style.transition = "opacity 0.5s";

    switch (type) {
        case "success": toastContainer.style.backgroundColor = "#28a745"; break;
        case "info": toastContainer.style.backgroundColor = "#17a2b8"; break;
        case "warning": toastContainer.style.backgroundColor = "#ffc107"; break;
        case "error": toastContainer.style.backgroundColor = "#dc3545"; break;
        default: toastContainer.style.backgroundColor = "#6c757d";
    }

    // Add to body
    document.body.appendChild(toastContainer);

    // Fade in
    toastContainer.style.opacity = "0";
    setTimeout(() => toastContainer.style.opacity = "1", 10);

    // Auto-hide after 5 seconds
    setTimeout(() => {
        toastContainer.style.opacity = "0";
        setTimeout(() => toastContainer.remove(), 500); // Remove after fade-out
    }, 5000);

}