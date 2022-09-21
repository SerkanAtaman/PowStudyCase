namespace POW.Cubes
{
    public enum CubeInteractType
    {
        None,
        Reserve,
    }

    public class CubeInteractAbility
    {
        public CubeInteractType InteractType;

        private readonly CubeMono _cube;

        public CubeInteractAbility(CubeMono cube)
        {
            _cube = cube;
        }

        public void Interact()
        {
            switch (InteractType)
            {
                case CubeInteractType.None:

                    break;

                case CubeInteractType.Reserve:

                    _cube.GetReserved();
                    break;
            }
        }
    }
}