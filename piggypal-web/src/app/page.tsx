import Link from 'next/link';

export default function Home() {
  return (
    <main className="min-h-screen bg-gradient-to-br from-pink-100 to-blue-100 flex flex-col items-center justify-center p-4">
      <section className="bg-white rounded-3xl shadow-xl p-8 max-w-xl w-full flex flex-col items-center">
        <h1 className="text-4xl font-extrabold text-pink-600 mb-2">🐷 PiggyPal</h1>
        <p className="text-lg text-gray-700 mb-6 text-center">
          Welcome to PiggyPal! Empower your kids to build good habits, earn rewards, and learn financial skills in a fun, interactive way.
        </p>
        <div className="flex flex-col gap-4 w-full mb-6">
          <Link href="/parent" className="w-full">
            <button className="w-full py-3 rounded-xl bg-blue-500 hover:bg-blue-600 text-white font-semibold text-lg shadow">Parent Dashboard</button>
          </Link>
          <Link href="/kid" className="w-full">
            <button className="w-full py-3 rounded-xl bg-green-500 hover:bg-green-600 text-white font-semibold text-lg shadow">Kid Dashboard</button>
          </Link>
          <Link href="/rewards" className="w-full">
            <button className="w-full py-3 rounded-xl bg-yellow-400 hover:bg-yellow-500 text-white font-semibold text-lg shadow">Reward Store</button>
          </Link>
        </div>
        <div className="flex flex-row gap-4 w-full justify-center mb-4">
          <button className="px-4 py-2 rounded-lg bg-purple-400 hover:bg-purple-500 text-white font-medium shadow">+ Add Kid</button>
          <button className="px-4 py-2 rounded-lg bg-pink-400 hover:bg-pink-500 text-white font-medium shadow">+ Assign Chore</button>
        </div>
        <div className="flex flex-row gap-6 mt-2">
          <Link href="/auth/login" className="text-blue-500 hover:underline text-sm">Login</Link>
          <span className="text-gray-300">|</span>
          <Link href="/auth/signup" className="text-blue-500 hover:underline text-sm">Sign Up</Link>
        </div>
      </section>
      <footer className="mt-8 text-gray-400 text-sm">Made for families, by a family</footer>
    </main>
  );
}
