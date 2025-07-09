import KidHeader from "../../components/KidHeader";
import ChoreList from "../../components/ChoreList";
import BadgeRow from "../../components/BadgeRow";
import GoalProgress from "../../components/GoalProgress";

const mockKid = {
  name: "Tommy",
  avatarUrl: "https://api.dicebear.com/7.x/bottts/svg?seed=Tommy",
  balance: 12,
};

const mockChores = [
  { id: 1, description: "Make your bed", done: true },
  { id: 2, description: "Brush your teeth", done: false },
  { id: 3, description: "Feed the dog", done: true },
  { id: 4, description: "Do homework", done: false },
];

const mockBadges = [
  { id: 1, name: "Helper", iconUrl: "/window.svg" },
  { id: 2, name: "Early Bird", iconUrl: "/globe.svg" },
];

const mockGoal = {
  goalName: "Buy a Toy Car",
  current: 12,
  target: 20,
};

export default function KidDashboard() {
  return (
    <main className="min-h-screen flex flex-col items-center bg-green-50 py-8 px-2">
      <section className="bg-white rounded-3xl shadow-xl p-6 max-w-md w-full flex flex-col items-center">
        <KidHeader
          name={mockKid.name}
          avatarUrl={mockKid.avatarUrl}
          balance={mockKid.balance}
        />
        <ChoreList chores={mockChores} />
        <BadgeRow badges={mockBadges} />
        <GoalProgress
          goalName={mockGoal.goalName}
          current={mockGoal.current}
          target={mockGoal.target}
        />
      </section>
    </main>
  );
}
