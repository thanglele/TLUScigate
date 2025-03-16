import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@': '/src', // Thiết lập alias để thay vì viết 'src', bạn có thể dùng '@'
    },
  },
});