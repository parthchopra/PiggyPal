type Chore = {
  id: number;
  description: string;
  done: boolean;
};

type ChoreListProps = {
  chores: Chore[];
};

export default function ChoreList({ chores }: Readonly<ChoreListProps>) {
  return (
    <div className="w-full mb-6">
      <h2 className="text-lg font-semibold text-gray-700 mb-2">
        Today&apos;s Chores
      </h2>
      <ul className="space-y-2">
        {chores.map((chore) => (
          <li
            key={chore.id}
            className={`flex items-center gap-3 p-3 rounded-lg shadow-sm bg-white border ${
              chore.done ? "border-green-300" : "border-gray-200"
            }`}
          >
            <input
              type="checkbox"
              checked={chore.done}
              readOnly
              className="accent-green-500 w-5 h-5"
            />
            <span
              className={
                chore.done ? "line-through text-gray-400" : "text-gray-800"
              }
            >
              {chore.description}
            </span>
            {chore.done && (
              <span className="ml-auto text-green-500 text-xl">✔️</span>
            )}
          </li>
        ))}
      </ul>
    </div>
  );
}
