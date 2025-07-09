export default function ParentDashboard() {
  return (
    <main className="min-h-screen flex flex-col items-center justify-center bg-blue-50">
      <section className="bg-white rounded-2xl shadow-lg p-8 max-w-lg w-full flex flex-col items-center">
        <h1 className="text-3xl font-bold text-blue-600 mb-2">
          Parent Dashboard
        </h1>
        <p className="text-gray-700 text-center mb-4">
          Manage kids, assign chores, track progress, and approve rewards here.
        </p>
        <div className="text-gray-400">(Coming soon...)</div>
      </section>
    </main>
  );
}
