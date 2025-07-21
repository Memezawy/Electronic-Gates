# Electronic-Gates

An interactive digital logic gate simulator built with Unity, designed as an educational tool for Mr. Nawar to demonstrate and explore fundamental concepts in digital electronics and Boolean logic.

## 🎯 Project Purpose

This project serves as an educational platform for learning digital logic concepts through hands-on interaction. Students and educators can visualize how basic logic gates operate, connect them to create complex circuits, and observe real-time signal propagation through the system.

## 🛠️ Technologies Used

- **C#** - Core game logic and Unity scripting
- **Unity Engine 2021.1.0f1** - Primary development platform and rendering engine
- **ShaderLab** - Shader programming for visual effects and UI rendering
- **HLSL** - High-Level Shading Language for advanced visual components

## ✨ Key Features

### Logic Gates
- **AND Gate** - Outputs true only when both inputs are true
- **OR Gate** - Outputs true when at least one input is true  
- **NOT Gate** - Inverts the input signal (true becomes false, false becomes true)

### Interactive Interface
- **Drag & Drop** - Click and drag gates to position them anywhere on the canvas
- **Wire Connections** - Connect gate inputs and outputs with visual wires
- **Real-time Simulation** - Watch signals propagate through your circuits instantly
- **Visual Feedback** - Gates and wires change color to indicate signal state (on/off)

### User Controls
- **Gate Placement** - Select gate type from the UI and click to place
- **Wire Management** - Click to start a wire connection, click target to complete
- **Power Nodes** - Toggle power sources on/off to test circuit behavior
- **Deletion** - Right-click on any gate to remove it and its connections
- **Clear All** - Press 'F' key to remove all wires quickly

## 🎮 How to Use

### Getting Started
1. **Place Gates**: Select a gate type (AND, OR, NOT) from the interface
2. **Position Gates**: Click on the canvas to place the selected gate
3. **Add Power**: Place power nodes to provide input signals
4. **Connect Wires**: Click on output nodes and drag to input nodes to create connections
5. **Test Logic**: Toggle power nodes and observe how signals flow through your circuit

### Controls
- **Left Click** - Place selected gate, start/end wire connections
- **Right Click** - Delete gate under cursor
- **Mouse Drag** - Move gates around the canvas
- **F Key** - Clear all wire connections
- **Mouse Over Power Node + Click** - Toggle power state

### Circuit Building Tips
- Start with simple circuits using one or two gates
- Use power nodes to provide different input combinations
- Observe how gate outputs change based on their input combinations
- Experiment with combining gates to create more complex logic functions

## 🚀 Installation & Setup

### Prerequisites
- Unity Engine 2021.1.0f1 or later
- Git for version control

### Setup Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/Memezawy/Electronic-Gates.git
   ```

2. Open in Unity:
   - Launch Unity Hub
   - Click "Add" and navigate to the cloned folder
   - Select the project folder and open

3. Run the Application:
   - Open the `MainScene` in the Scenes folder
   - Press the Play button in Unity Editor
   - Or build the project for your target platform

## 📁 Project Structure

```
Assets/
├── Scripts/           # Core game logic
│   ├── BaseGate.cs    # Base class for all logic gates
│   ├── AndGate.cs     # AND gate implementation
│   ├── OrGate.cs      # OR gate implementation
│   ├── NotGate.cs     # NOT gate implementation
│   ├── WiresManager.cs # Wire connection system
│   └── ...
├── Prefabs/           # Reusable game objects
│   └── Gates/         # Gate prefab variants
├── Scenes/            # Unity scenes
│   ├── MainScene.unity # Primary application scene
│   └── TestingScene.unity
├── Art/               # Visual assets and UI graphics
└── ...
```

## 🎓 Educational Value

This simulator helps students understand:
- **Boolean Logic** - How true/false values combine in different ways
- **Digital Circuit Design** - Building circuits from basic components
- **Signal Flow** - Visualizing how information moves through circuits
- **Logic Gate Truth Tables** - Seeing gate behavior through interaction
- **Circuit Troubleshooting** - Testing and validating circuit designs

## 🤝 Contributing

This project is designed for educational use in Mr. Nawar's curriculum. For suggestions or improvements, please reach out to the project maintainers.

## 📄 License

This project is created for educational purposes under the guidance of Mr. Nawar.

---

*Built with ❤️ for digital logic education*