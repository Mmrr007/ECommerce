// In wwwroot/js/modules/cart.js
export function initAddToCart() {
    document.querySelectorAll('.btn-add-to-cart').forEach(btn => {
        btn.addEventListener('click', async function () {
            const productId = this.dataset.productId;
            try {
                const response = await fetch('/api/cart/add', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                    },
                    body: JSON.stringify({ productId, quantity: 1 })
                });

                if (response.ok) {
                    updateCartCount();
                    showToast('Product added to cart');
                }
            } catch (error) {
                console.error('Error adding to cart:', error);
            }
        });
    });
}