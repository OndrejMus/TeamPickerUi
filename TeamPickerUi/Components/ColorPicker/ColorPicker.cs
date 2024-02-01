namespace TeamPickerUi.Components.ColorPicker
{
    public class ColorPicker
    {
        private string _color;
        public string Color 
        { 
            get { return (_color.StartsWith('#') ? _color : "#" + _color); }
            set { _color = value; } 
        }
        public string AlphaString { get; set; } = "255";
        public string AlphaHex
        {
            get { return byte.Parse(AlphaString).ToString("x2"); }
        }
        public string ColorWithAlphaHex
        {
            get { return (Color.StartsWith('#') ? Color : "#"+Color) + AlphaHex; }


        }

        public void SetRandomColor()
        {
            string hex = string.Format("{0}{1}{2}", GetRandomByte(), GetRandomByte(), GetRandomByte());

            _color = hex;

        }
        private string GetRandomByte()
        {
            return Random.Shared.Next(0, 256).ToString("x2");
        }
    }
}
